import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {SelectItem} from 'primeng/api';
import {TreeTechService} from '../../services/treetech-service';
import {Router} from '@angular/router';
import {faSearch, faArrowCircleLeft, faListOl} from '@fortawesome/free-solid-svg-icons';
import {AlarmeFiltro} from '../../models/alarme/alarme';
import * as moment from 'moment';
import {EquipamentoDTO} from '../../models/equipamento/equipamento';


@Component({
  selector: 'app-alarme-atuados',
  templateUrl: './alarme-atuados.component.html',
  styleUrls: ['./alarme-atuados.component.css']
})
export class AlarmeAtuadosComponent implements OnInit {
  public formulario: FormGroup;
  public tiposEquipamento: SelectItem[];
  public tiposAlarme: SelectItem[];
  public numeroAlarmesAtuados: SelectItem[];
  public equipamentos: EquipamentoDTO[];
  public buscandoOcorrencias: boolean;
  public alarmes: any[];
  public ocorrencias: any[];
  faSearch = faSearch;
  faArrowCircleLeft = faArrowCircleLeft;
  faListOl = faListOl;

  constructor(
    public treeTechService: TreeTechService,
    private _router: Router,
    private _fb: FormBuilder
  ) {
  }

  ngOnInit(): void {
    this.carregarTiposAlarmes();
    this.carregarTiposEquipamentos();
    this.construirFormulario();
    this.carregarEquipamentos();
    this.carregarNumerosAlarmesAtuados();
    this.pesquisar();
    this.buscandoOcorrencias = false;
  }

  construirFormulario(): void {
    this.formulario = this._fb.group({
      descricao: [],
      tipoAlarme: [],
      tipoEquipamento: [],
      dataEvento: [],
      numeroSerie: [],
      equipamento: [],
      numeroAlarmeAtuado: []
    });
  }

  carregarTiposEquipamentos(): void {
    this.tiposEquipamento = [
      {label: 'Tensão', value: 1},
      {label: 'Corrente', value: 2},
      {label: 'Oléo', value: 3},
    ];
  }

  carregarTiposAlarmes(): void {
    this.tiposAlarme = [
      {label: 'Baixo', value: 1},
      {label: 'Médio', value: 2},
      {label: 'Alto', value: 3}
    ];
  }

  carregarEquipamentos(): void {
    this.treeTechService.ListarEquipamentos().subscribe(data => {
      this.equipamentos = data;
      if (this.equipamentos.length === 0) {
        this.equipamentos = [{
          nomeEquipamento: 'Não há Equipamentos cadastrados'
        }];
      }
    });
  }

  carregarNumerosAlarmesAtuados(): void {
    this.numeroAlarmesAtuados = [
      {label: '1', value: 1},
      {label: '2', value: 2},
      {label: '3', value: 3},
      {label: '4', value: 4},
      {label: '5', value: 5},
      {label: '6', value: 6},
      {label: '7', value: 7},
      {label: '8', value: 8},
      {label: '9', value: 9},
      {label: '10', value: 10},
    ];
  }

  buscarOcorrencias(): void {
    const numeroOcorrencias = this.formulario.value.numeroAlarmeAtuado;
    this.treeTechService.BuscarOcorrenciasAlarmesAtuados(numeroOcorrencias).subscribe(data => {
      this.ocorrencias = data;
      this.buscandoOcorrencias = true;
      console.log(this.ocorrencias);
    });
  }

  voltar(): void {
    this._router.navigate(['alarme/lista']);
  }

  pesquisar(): void {
    console.log(this.formulario);
    const filtro: AlarmeFiltro = {
      descricao: this.formulario.value?.descricao,
      ativo: this.formulario.value?.statusAlarme,
      tipoAlarme: this.formulario.value?.tipoAlarme,
      tipoEquipamento: this.formulario.value?.tipoEquipamento,
      numeroSerie: this.formulario.value?.numeroSerie,
      nomeEquipamento: this.formulario.value?.equipamento?.nomeEquipamento === undefined ?
        null : this.formulario.value?.equipamento?.nomeEquipamento
      // dataCadastro: moment(this.formulario.value?.dataEvento, 'DD/MM/YYYY').toDate()
    };
    // console.log('filtro', filtro);
    this.treeTechService.ListarAlarmesAtuadosPorFiltro(filtro).subscribe(data => {
      console.log(data);
      this.buscandoOcorrencias = false;
      this.alarmes = data;
    });
  }
}
