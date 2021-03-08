import {Component, OnInit} from '@angular/core';
import {MessageService, SelectItem} from 'primeng/api';
import {FormBuilder, FormGroup} from '@angular/forms';
import {faEdit, faPlusCircle, faSearch, faTrash, faToggleOn, faToggleOff, faEye, faBell} from '@fortawesome/free-solid-svg-icons';
import {TreeTechService} from '../../services/treetech-service';
import {DatePipe} from '@angular/common';
import {Router} from '@angular/router';
import {EquipamentoDTO, EquipamentoFiltro} from '../../models/equipamento/equipamento';
import {AlarmeFiltro} from '../../models/alarme/alarme';
import {environment} from '../../../environments/environment';
import {NgxSpinnerService} from 'ngx-spinner';

@Component({
  selector: 'app-alarme-listagem',
  templateUrl: './alarme-listagem.component.html',
  styleUrls: ['./alarme-listagem.component.css']
})
export class AlarmeListagemComponent implements OnInit {
  public equipamentos: EquipamentoDTO[];
  public tiposAlarme: SelectItem[];
  public statusAlarme: SelectItem[];
  public formulario: FormGroup;
  public alarmes: any[];

  faPlusCircle = faPlusCircle;
  faSearch = faSearch;
  faEdit = faEdit;
  faTrash = faTrash;
  faToggleOn = faToggleOn;
  faToggleOff = faToggleOff;
  faEye = faEye;
  faBell = faBell;

  constructor(
    private _router: Router,
    private _fb: FormBuilder,
    public treeTechService: TreeTechService,
    private message: MessageService,
    private spinner: NgxSpinnerService
  ) {
  }

  ngOnInit(): void {
    this.construirFormulario();
    this.carregarTiposAlarmes();
    this.carregarEquipamentos();
    this.carregarStatusAlarme();
    this.pesquisar();
  }

  construirFormulario(): void {
    this.formulario = this._fb.group({
      descricao: [],
      equipamento: [],
      tipoAlarme: [],
      statusAlarme: []
    });
  }

  carregarTiposAlarmes(): void {
    this.tiposAlarme = [
      {label: 'Baixo', value: 1},
      {label: 'Médio', value: 2},
      {label: 'Alto', value: 3}
    ];
  }

  carregarEquipamentos(): void {
    this.spinner.show();
    this.treeTechService.ListarEquipamentos().subscribe(data => {
      this.equipamentos = data;
      this.spinner.hide();
      if (this.equipamentos.length === 0) {
        this.equipamentos = [{
          nomeEquipamento: 'Não há Equipamentos cadastrados'
        }];
      }
    });
  }

  carregarStatusAlarme(): void {
    this.statusAlarme = [
      {label: 'Inativo', value: 0},
      {label: 'Ativo', value: 1},
    ];
  }

  pesquisar(): void {
    this.spinner.show();
    const filtro: AlarmeFiltro = {
      descricao: this.formulario.value?.descricao,
      idEquipamento: this.formulario.value?.equipamento?.id === undefined ? null : this.formulario.value?.equipamento?.id,
      ativo: this.formulario.value?.statusAlarme,
      tipoAlarme: this.formulario.value?.tipoAlarme
    };
    this.treeTechService.ListarAlarmesPorFiltro(filtro).subscribe(data => {
      this.alarmes = data;
      this.spinner.hide();
    });
  }

  cadastrarAlarme(): void {
    this._router.navigate(['alarme/cadastro']);
  }

  atualizar(alarme: any): void {
    this._router.navigate(['alarme/cadastro'], { queryParams : {id: alarme.id}});
  }

  deletar(alarme: any): void {
    this.spinner.show();
    this.treeTechService.DeletarAlarme(alarme.id).subscribe(result => {
        if (result) {
          this.message.add({
            severity: 'success',
            summary: 'Sucesso',
            detail: `Remoção do Alarme realizada com sucesso`
          });
          this.alarmes = this.alarmes.filter(x => {
            return x.id !== alarme.id;
          });
        } else {
          this.message.add({
            severity: 'warn',
            summary: 'Aviso',
            detail: `Remoção do Alarme não pode ser realizada`
          });
          this.spinner.hide();
        }
      },
      err => {
        if (err) {
          this.message.add({
            severity: 'error',
            summary: 'Erro',
            detail: 'Erro ao tentar remover esse Alarme'
          });
        }
      });
  }

  ativarOuDesativarAlarme(alarme: any): void {
    this.spinner.show();
    this.treeTechService.AtivarOuDesativarAlarme(alarme).subscribe(result => {
        if (result) {
          if (alarme.ativo){
            this.message.add({
              severity: 'success',
              summary: 'Sucesso',
              detail: `Desativação do Alarme realizada com sucesso`
            });
          } else {
            this.message.add({
              severity: 'success',
              summary: 'Sucesso',
              detail: `Ativação do Alarme realizada com sucesso`
            });
          }
          alarme.ativo = !alarme.ativo;
          if (alarme.tipoAlarme === 3 && alarme.ativo) {
            this.message.add({
              severity: 'success',
              summary: 'Sucesso',
              detail: `Email enviado com sucesso`
            });
          }
        } else {
          this.message.add({
            severity: 'warn',
            summary: 'Aviso',
            detail: `Ativação do Alarme não pode ser realizada`
          });
        }
        this.spinner.hide();
      },
      err => {
        if (err) {
          this.message.add({
            severity: 'error',
            summary: 'Erro',
            detail: 'Erro ao tentar ativar esse Alarme'
          });
        }
        this.spinner.hide();
      });
  }

  visualizar(alarme: any): void {
    this._router.navigate(['alarme/visualizar'], { queryParams : {id: alarme.id}});
  }

  alarmesAtuados(): void {
    this._router.navigate(['alarme/atuados']);
  }
}
