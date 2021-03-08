import {Component, OnInit} from '@angular/core';
import {MessageService, SelectItem} from 'primeng/api';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {TreeTechService} from '../../services/treetech-service';
import {faPlusCircle, faArrowCircleLeft} from '@fortawesome/free-solid-svg-icons';
import {EquipamentoDTO} from '../../models/equipamento/equipamento';
import {AlarmeDTO} from '../../models/alarme/alarme';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-alarme-cadastro',
  templateUrl: './alarme-cadastro.component.html',
  styleUrls: ['./alarme-cadastro.component.css']
})
export class AlarmeCadastroComponent implements OnInit {
  public equipamentos: EquipamentoDTO[];
  public alarme: AlarmeDTO;
  public tiposAlarme: SelectItem[];
  public formulario: FormGroup;
  public atualizandoAlarme: boolean;
  faPlusCircle = faPlusCircle;
  faArrowCircleLeft = faArrowCircleLeft;

  constructor(
    private _router: Router,
    private _fb: FormBuilder,
    public treeTechService: TreeTechService,
    private message: MessageService,
    private _route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.carregarEquipamentos();
    this.verificarFluxo();
    this.carregarTiposAlarme();
    this.construirFormulario();
    this.atualizandoAlarme = false;
  }

  construirFormulario(): void {
    this.formulario = this._fb.group({
      equipamento: ['', Validators.required],
      descricao: ['', Validators.required],
      tipoAlarme: ['', Validators.required]
    });
  }

  carregarTiposAlarme(): void {
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

  verificarFluxo(): void {
    this._route.queryParams.subscribe((params) => {
      if (params.id !== undefined) {
        const id = params.id;
        this.treeTechService.BuscarAlarmePorId(id).subscribe(data => {
          this.formulario.get('equipamento').setValue(data.equipamentoDTO);
          this.formulario.get('descricao').setValue(data.descricao);
          this.formulario.get('tipoAlarme').setValue(data.tipoAlarme);
          this.atualizandoAlarme = true;
          this.alarme = data;
          console.log(data);
          console.log(this.formulario);
        });
      }
    });
  }

  cadastrarOuAtualizarAlarme(): void{
    if (this.formulario.status === 'VALID') {
      if (!this.atualizandoAlarme) {
        this.cadastrar();
      } else {
        this.atualizar();
      }
    } else {
      if (this.formulario.controls.equipamento.errors){
        this.formulario.get('equipamento').markAsTouched();
        this.formulario.get('equipamento').markAsDirty();
      }
      if (this.formulario.controls.descricao.errors){
        this.formulario.get('descricao').markAsTouched();
      }
      if (this.formulario.controls.tipoAlarme.errors){
        this.formulario.get('tipoAlarme').markAsTouched();
        this.formulario.get('tipoAlarme').markAsDirty();
      }
      this.message.add({
        severity: 'warn',
        summary: 'Aviso',
        detail: `Preencha os campos obrigatórios`
      });
    }
    // this.voltar();
  }

  cadastrar(): void {
    const dto: AlarmeDTO = {
      descricao: this.formulario.value.descricao,
      tipoAlarme: this.formulario.value.tipoAlarme,
      idEquipamento: this.formulario.value.equipamento.id,
    };

    this.treeTechService.CadastrarAlarme(dto).subscribe(data => {
        console.log(data);
        this.message.add({
          severity: 'success',
          summary: 'Sucesso',
          detail: `Cadastro do Alarme realizado com sucesso`
        });
      },
      err => {
        console.log(err);
        if (err) {
          this.message.add({
            severity: 'error',
            summary: 'Erro',
            detail: 'Erro ao tentar cadastrar esse Alarme'
          });
        }
      });
  }

  voltar(): void {
    this._router.navigate(['alarme/lista']);
  }

  atualizar(): void{
    const dto: AlarmeDTO = {
      id: this.alarme.id,
      descricao: this.formulario.value.descricao,
      idEquipamento: this.formulario.value.equipamento.id,
      tipoAlarme: this.formulario.value.tipoAlarme
    };
    this.treeTechService.AtualizarAlarme(dto).subscribe(data => {
        this.message.add({
          severity: 'success',
          summary: 'Sucesso',
          detail: `Atualização do Alarme realizado com sucesso`
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
  // numeroSerieFormatado(): string {
  //   return `${this.numeroSerie.substring(0, 5)}-${this.numeroSerie.substring(5, 8)}-${this.numeroSerie[8]}-${this.numeroSerie.substring(9, 13)}/${this.numeroSerie.substring(13, 17)}`;
  // }
}
