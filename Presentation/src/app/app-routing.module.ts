import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LayoutComponent} from './shared/layout/layout.component';
import {AlarmeListagemComponent} from './alarme/alarme-listagem/alarme-listagem.component';
import {EquipamentoListagemComponent} from './equipamento/equipamento-listagem/equipamento-listagem.component';
import {AlarmeCadastroComponent} from './alarme/alarme-cadastro/alarme-cadastro.component';
import {EquipamentoCadastroComponent} from './equipamento/equipamento-cadastro/equipamento-cadastro.component';
import {AlarmeVisualizarComponent} from './alarme/alarme-visualizar/alarme-visualizar.component';
import {AlarmeAtuadosComponent} from './alarme/alarme-atuados/alarme-atuados.component';

const routes: Routes = [{
  path: '',
  component: LayoutComponent,
  children : [
    { path: 'alarme/lista', component: AlarmeListagemComponent},
    { path: 'alarme/cadastro', component: AlarmeCadastroComponent},
    { path: 'alarme/visualizar', component: AlarmeVisualizarComponent},
    { path: 'alarme/atuados', component: AlarmeAtuadosComponent},
    { path: 'equipamento/lista', component: EquipamentoListagemComponent},
    { path: 'equipamento/cadastro', component: EquipamentoCadastroComponent}
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
