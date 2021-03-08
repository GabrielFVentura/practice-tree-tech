import {Component, OnInit} from '@angular/core';
import {faSearch, faPlusCircle, faEdit, faTrash} from '@fortawesome/free-solid-svg-icons';
import {FormBuilder, FormGroup} from '@angular/forms';
import {MessageService, SelectItem} from 'primeng/api';
import {TreeTechService} from '../../services/treetech-service';
import {Router} from '@angular/router';
import {EquipamentoDTO, EquipamentoFiltro} from '../../models/equipamento/equipamento';

@Component({
  selector: 'app-equipamento-listagem',
  templateUrl: './equipamento-listagem.component.html',
  styleUrls: ['./equipamento-listagem.component.css']
})
export class EquipamentoListagemComponent implements OnInit {
  public formulario: FormGroup;
  faPlusCircle = faPlusCircle;
  faSearch = faSearch;
  faEdit = faEdit;
  faTrash = faTrash;

  tiposEquipamento: SelectItem[];
  statusEquipamento: SelectItem[];
  equipamentos: any;

  constructor(
    private _router: Router,
    private _fb: FormBuilder,
    public treeTechService: TreeTechService,
    private message: MessageService,
  ) {
    this.formulario = this._fb.group({
      tipoEquipamento: [],
      numeroSerie: [],
      nomeEquipamento: []
    });
  }

  ngOnInit(): void {
    this.pesquisar();
    this.carregarTiposEquipamento();
    this.carregarStatusEquipamento();
  }

  carregarTiposEquipamento(): void {
    this.tiposEquipamento = [
      {label: 'Tensão', value: 1},
      {label: 'Corrente', value: 2},
      {label: 'Oléo', value: 3},
    ];
  }

  carregarStatusEquipamento(): void {
    this.statusEquipamento = [
      {label: 'Inativo', value: 0},
      {label: 'Ativo', value: 1}
    ];
  }

  cadastrarEquipamento(): void {
    this._router.navigate(['equipamento/cadastro']);
  }

  pesquisar(): void {
    const filtro: EquipamentoFiltro = {
      nomeEquipamento: this.formulario.value?.nomeEquipamento,
      numeroSerie: this.formulario.value?.numeroSerie,
      tipoEquipamento: this.formulario.value?.tipoEquipamento
    };

    this.treeTechService.ListarEquipamentosPorFiltro(filtro).subscribe(data => {
      this.equipamentos = data;
    });
  }

  atualizar(equipamento: EquipamentoDTO): void {
    this._router.navigate(['equipamento/cadastro'], { queryParams : {id: equipamento.id}});
  }

  deletar(equipamento: any): void {
    this.treeTechService.DeletarEquipamento(equipamento.id).subscribe(result => {
        if (result) {
          this.message.add({
            severity: 'success',
            summary: 'Sucesso',
            detail: `Remoção do Equipamento ${equipamento.nomeEquipamento} realizada com sucesso`
          });
          this.equipamentos = this.equipamentos.filter(x => {
            return x.id !== equipamento.id;
          });
        } else {
          this.message.add({
            severity: 'warn',
            summary: 'Aviso',
            detail: `Remoção do Equipamento ${equipamento.nomeEquipamento} não pode ser efetuada, existe um alarme associado a esse Equipamento`
          });
        }
      },
      err => {
        if (err) {
          this.message.add({
            severity: 'error',
            summary: 'Erro',
            detail: 'Erro ao tentar remover esse Equipamento'
          });
        }
      });
  }
}
