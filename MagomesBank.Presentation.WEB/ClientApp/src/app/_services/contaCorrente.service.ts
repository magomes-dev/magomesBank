import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { map } from 'rxjs/operators';
import { ContaCorrenteDTO } from '../_models/contaCorrenteDTO';
import { ResponseDto } from '../_models/ResponseDTO';

@Injectable({ providedIn: 'root' })
export class ContaCorrenteService {
    constructor(private http: HttpClient) { }

    operacao(ContaCorrenteId: number, value: number, tipoMovimento: string) {
        return this.http.post<ResponseDto>(`${environment.apiUrl}/ContaCorrente/${ContaCorrenteId}/${tipoMovimento}`, { "valor": value })
        .pipe(map(result => {
            return result;
        }));
    }

    consulta(clientId: number){
        return this.http.get<ContaCorrenteDTO>(`${environment.apiUrl}/ContaCorrente/${clientId}/consultaPorUsuario`)
        .pipe(map(result => {
            return result;
        }));
    }
}