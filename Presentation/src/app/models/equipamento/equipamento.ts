export class EquipamentoDTO{
  id?: string;
  dataCadastro?: string;
  dataAlteracao?: string;
  nomeEquipamento?: string;
  numeroSerie?: string;
  tipoEquipamento?: number;
}

export class EquipamentoFiltro{
  nomeEquipamento?: string;
  numeroSerie?: string;
  tipoEquipamento?: number;
}
