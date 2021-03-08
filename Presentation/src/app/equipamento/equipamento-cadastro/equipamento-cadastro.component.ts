import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {faPlusCircle, faArrowCircleLeft} from '@fortawesome/free-solid-svg-icons';
import {TreeTechService} from '../../services/treetech-service';
import {MessageService, SelectItem} from 'primeng/api';
import {ActivatedRoute, Router} from '@angular/router';
import {EquipamentoDTO} from '../../models/equipamento/equipamento';

@Component({
  selector: 'app-equipamento-cadastro',
  templateUrl: './equipamento-cadastro.component.html',
  styleUrls: ['./equipamento-cadastro.component.css']
})
export class EquipamentoCadastroComponent implements OnInit {
  faPlusCircle = faPlusCircle;
  faArrowCircleLeft = faArrowCircleLeft;
  public formulario: FormGroup;
  public tiposEquipamento: SelectItem[];
  public atualizandoEquipamento: boolean;
  public equipamento: EquipamentoDTO;

  constructor(
    private _fb: FormBuilder,
    private _router: Router,
    public treeTechService: TreeTechService,
    private message: MessageService,
    private _route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.construirFormulario();
    this.carregarTiposEquipamentos();
    this.verificarFluxo();
  }

  construirFormulario(): void {
    this.formulario = this._fb.group({
      tipoEquipamento: ['', Validators.required],
      numeroSerie: ['', Validators.required],
      nomeEquipamento: ['', Validators.required]
    });
  }

  carregarTiposEquipamentos(): void {
    this.tiposEquipamento = [
      {label: 'Tensão', value: 1},
      {label: 'Corrente', value: 2},
      {label: 'Oléo', value: 3},
    ];
  }

  verificarFluxo(): void {
    this._route.queryParams.subscribe((params) => {
      if (params.id !== undefined) {
        const id = params.id;
        this.treeTechService.BuscarEquipamentoPorId(id).subscribe(data => {
          this.formulario.get('numeroSerie').setValue(data.numeroSerie);
          this.formulario.get('nomeEquipamento').setValue(data.nomeEquipamento);
          this.formulario.get('tipoEquipamento').setValue(data.tipoEquipamento);
          this.atualizandoEquipamento = true;
          this.equipamento = data;
        });
      }
    });
  }

  cadastrarOuAtualizarEquipamento(): void {
    console.log(this.formulario);
    if (this.formulario.status === 'VALID'){
      if (!this.atualizandoEquipamento) {
        this.cadastrar();
      } else {
        this.atualizar();
      }
      // this.voltar();
    } else {
      if (this.formulario.controls.nomeEquipamento.errors){
        this.formulario.get('nomeEquipamento').markAsTouched();
      }
      if (this.formulario.controls.numeroSerie.errors){
        this.formulario.get('numeroSerie').markAsTouched();
      }
      if (this.formulario.controls.tipoEquipamento.errors){
        this.formulario.get('tipoEquipamento').markAsTouched();
        this.formulario.get('tipoEquipamento').markAsDirty();
      }
      this.message.add({
        severity: 'warn',
        summary: 'Aviso',
        detail: `Preencha os campos obrigatórios`
      });
    }
  }

  cadastrar(): void {

    const dto: EquipamentoDTO = {
      nomeEquipamento: this.formulario.value.nomeEquipamento,
      numeroSerie: this.formulario.value.numeroSerie,
      tipoEquipamento: this.formulario.value.tipoEquipamento
    };

    this.treeTechService.CadastrarEquipamento(dto).subscribe(data => {
        console.log(data);
        this.message.add({
          severity: 'success',
          summary: 'Sucesso',
          detail: `Cadastro do Equipamento "${data.nomeEquipamento}" realizado com sucesso`
        });
      },
      err => {
        console.log(err);
        if (err) {
          this.message.add({
            severity: 'error',
            summary: 'Erro',
            detail: `${err.error}`
          });
        }
      });
  }

  atualizar(): void {
    const dto: EquipamentoDTO = {
      id: this.equipamento.id,
      nomeEquipamento: this.formulario.value.nomeEquipamento,
      numeroSerie: this.formulario.value.numeroSerie,
      tipoEquipamento: this.formulario.value.tipoEquipamento
    };
    this.treeTechService.AtualizarEquipamento(dto).subscribe(data => {
        this.message.add({
          severity: 'success',
          summary: 'Sucesso',
          detail: `Atualização do Equipamento "${data.nomeEquipamento}" realizado com sucesso`
        });
      },
      err => {
        console.log(err);
        if (err) {
          this.message.add({
            severity: 'error',
            summary: 'Erro',
            detail: 'Erro ao tentar atualizar esse Equipamento'
          });
        }
      });
  }

  voltar(): void {
    this._router.navigate(['equipamento/lista']);
  }
}
