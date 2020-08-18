import { Component } from '@angular/core';
import { first } from 'rxjs/operators';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContaCorrenteService } from '../_services/contaCorrente.service';
import { AuthenticationService } from '@app/_services';


@Component({
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    depositForm: FormGroup;
    withdrawForm: FormGroup;
    paymentForm: FormGroup;
    loading = false;
    submittedDeposit = false;
    submittedWithdraw = false;
    submittedPayment = false;
    returnUrl: string;
    error = '';
    dados;
    clientId;

    constructor(
        private formBuilder: FormBuilder,
        private _contaCorrenteService: ContaCorrenteService,
        private authenticationService: AuthenticationService,
    ) {
    }

    ngOnInit() {
        this.clientId = this.authenticationService.currentUserValue.id;

        this._contaCorrenteService.consulta(this.clientId).pipe(first()).subscribe(
            data => {
                console.log('Data', data)
                this.dados = data;
            });

        this.depositForm = this.formBuilder.group({
            depositAmount: ['', Validators.required],
        });

        this.withdrawForm = this.formBuilder.group({
            withdrawAmount: ['', Validators.required],
        });

        this.paymentForm = this.formBuilder.group({
            paymentAmount: ['', Validators.required],
        });
    }


    get fd() { return this.depositForm.controls; }
    get fw() { return this.withdrawForm.controls; }
    get fp() { return this.paymentForm.controls; }



    onSubmitDeposit() {
        this.submittedDeposit = true;

        if (this.depositForm.invalid) {
            return;
        }
        this.makeRequest(this.fd.depositAmount.value, "depositar");
        this.loading = true;

    }

    onSubmitWithdraw() {
        this.submittedWithdraw = true;

        if (this.withdrawForm.invalid) {
            return;
        }

        this.makeRequest(this.fw.withdrawAmount.value, "resgatar");
        this.loading = true;

    }
    onSubmitPayment() {
        this.submittedPayment = true;

        if (this.paymentForm.invalid) {
            return;
        }

        this.makeRequest(this.fp.paymentAmount.value, "pagar");
        this.loading = true;

    }

    clearForm() {
        this.submittedDeposit = false;
        this.submittedPayment = false,
        this.submittedWithdraw = false;
        this.depositForm.reset();
        this.withdrawForm.reset();
        this.paymentForm.reset();
    }

    logout(){
        this.authenticationService.logout();
        location.reload(true);
    }

    makeRequest(value: number, transacao: string) {
        this.error = '';

        this._contaCorrenteService.operacao(this.dados.id, value, transacao)
            .pipe(first())
            .subscribe(
                data => {
                    if (data.success) {
                        this.ngOnInit()
                        this.clearForm();
                    }
                    else {
                        this.error = data.message;
                    }
                    this.loading = false;
                },
                error => {
                    this.error = error;
                    this.loading = false;
                });
    }
    
    descrTipoMovimento(tipoMovimento){
        return tipoMovimento == 1 ? 'Depósito' : tipoMovimento == 2 ? 'Resgate' :  tipoMovimento == 3 ? 'Pagamento' : 'Rentabilização'
    }
}