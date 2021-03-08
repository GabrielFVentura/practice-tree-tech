import {EquipamentoDTO} from '../equipamento/equipamento';

export class AlarmeDTO {
  id?: string;
  descricao?: string;
  tipoAlarme?: string;
  ativo?: boolean;
  idEquipamento?: string;
  dataCadastro?: string;
  dataAtualizacao?: string;
  equipamentoDTO?: EquipamentoDTO;
}

export class AlarmeFiltro {
  descricao?: string;
  idEquipamento?: string;
  ativo?: number;
  tipoAlarme?: number;
  dataCadastro?: Date;
  tipoEquipamento?: string;
  numeroSerie?: string;
  nomeEquipamento?: string;
}

export class AlarmeAtuadoDTO {
  id?: string;
  dataCadastro?: string;
  idEquipamento?: string;
  alarmeDTO?: AlarmeDTO;
  idAlarme?: string;
  tipoAlarme?: string;
  nomeEquipamento?: string;
  numeroSerie: string;
  tipoEquipamento: string;
}
