import {MovimentoDTO} from '@app/_models/movimentoDTO'

export class ContaCorrenteDTO {
    id: number;
    saldo: number;
    nomeUsuario: string;
    movimentos: Array<MovimentoDTO>
}