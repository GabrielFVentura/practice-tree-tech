import {BrowserModule} from '@angular/platform-browser';
import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HeaderComponent} from './shared/layout/header/header.component';
import {LayoutComponent} from './shared/layout/layout.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MenuModule} from 'primeng/menu';
import {MenubarModule} from 'primeng/menubar';
import {ButtonModule} from 'primeng/button';
import {InputTextModule} from 'primeng/inputtext';
import {AlarmeCadastroComponent} from './alarme/alarme-cadastro/alarme-cadastro.component';
import {AlarmeListagemComponent} from './alarme/alarme-listagem/alarme-listagem.component';
import {EquipamentoListagemComponent} from './equipamento/equipamento-listagem/equipamento-listagem.component';
import {SharedModule} from './shared/shared.module';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';
import {HttpClientModule} from '@angular/common/http';
import {TreeTechService} from './services/treetech-service';
import {EquipamentoCadastroComponent} from './equipamento/equipamento-cadastro/equipamento-cadastro.component';
import {MessageService} from 'primeng/api';
import {ToastModule} from 'primeng/toast';
import {NgxMaskModule} from 'ngx-mask';
import {AlarmeVisualizarComponent} from './alarme/alarme-visualizar/alarme-visualizar.component';
import {AlarmeAtuadosComponent} from './alarme/alarme-atuados/alarme-atuados.component';
import {NgxSpinnerModule} from 'ngx-spinner';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LayoutComponent,
    AlarmeCadastroComponent,
    AlarmeListagemComponent,
    EquipamentoListagemComponent,
    EquipamentoCadastroComponent,
    AlarmeVisualizarComponent,
    AlarmeAtuadosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MenuModule,
    MenubarModule,
    InputTextModule,
    ButtonModule,
    SharedModule,
    FontAwesomeModule,
    HttpClientModule,
    ToastModule,
    NgxMaskModule.forRoot(),
    NgxSpinnerModule
  ],
  providers: [
    TreeTechService,
    MessageService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [AppComponent]
})
export class AppModule {
}
