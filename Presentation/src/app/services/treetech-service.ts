import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {EquipamentoDTO, EquipamentoFiltro} from '../models/equipamento/equipamento';
import {AlarmeDTO, AlarmeFiltro} from '../models/alarme/alarme';

const headersString = {
  'Content-Type': 'application/json',
  'Access-Control-Allow-Origin': '*',
  'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, PATCH, DELETE',
  'Access-Control-Allow-Headers':
    'Access-Control-Allow-Headers, ' +
    'Origin, ' +
    'Accept, ' +
    'X-Requested-With, ' +
    'Content-Type, ' +
    'Access-Control-Request-Method, ' +
    'Access-Control-Request-Headers'
};

const httpOptions = {
  headers: new HttpHeaders(headersString)
};

@Injectable()
export class TreeTechService {
  private url = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {
  }

  // ALARME
  public ListarAlarmesPorFiltro(filtro: AlarmeFiltro): Observable<any> {
    return this.http.post(this.url + 'Alarme/BuscarPorFiltroAlarme', filtro, httpOptions);
  }

  public CadastrarAlarme(dto: AlarmeDTO): Observable<any> {
    return this.http.post(this.url + 'Alarme/Cadastrar', dto, httpOptions);
  }

  public BuscarAlarmePorId(id: string): Observable<any> {
    return this.http.get(this.url + 'Alarme/BuscarAlarmePorId/' + id, httpOptions);
  }

  public AtualizarAlarme(dto: AlarmeDTO): Observable<AlarmeDTO> {
    return this.http.put<any>(this.url + 'Alarme/Atualizar/' + dto.id, dto, httpOptions);
  }

  public DeletarAlarme(id: string): Observable<AlarmeDTO> {
    return this.http.delete<any>(this.url + 'Alarme/Deletar/' + id, httpOptions);
  }

  public AtivarOuDesativarAlarme(dto: AlarmeDTO): Observable<any> {
    return this.http.post(this.url + 'Alarme/AtivarOuDesativarAlarme/', dto, httpOptions);
  }

  // EQUIPAMENTO
  public ListarEquipamentos(): Observable<any> {
    return this.http.get(this.url + 'Equipamento/BuscarTodos');
  }

  public CadastrarEquipamento(dto: EquipamentoDTO): Observable<any> {
    return this.http.post(this.url + 'Equipamento/Cadastrar', dto, httpOptions);
  }

  public BuscarEquipamentoPorId(id: string): Observable<EquipamentoDTO> {
    return this.http.get(this.url + 'Equipamento/BuscarEquipamentoPorId/' + id, httpOptions);
  }

  public AtualizarEquipamento(dto: EquipamentoDTO): Observable<EquipamentoDTO> {
    return this.http.put<any>(this.url + 'Equipamento/Atualizar/' + dto.id, dto, httpOptions);
  }

  public DeletarEquipamento(id: string): Observable<EquipamentoDTO> {
    return this.http.delete<any>(this.url + 'Equipamento/Deletar/' + id, httpOptions);
  }

  public ListarEquipamentosPorFiltro(filtro: EquipamentoFiltro): Observable<any> {
    return this.http.post(this.url + 'Equipamento/BuscarPorFiltroEquipamento', filtro, httpOptions);
  }

  // ALARME ATUADO
  public ListarAlarmesAtuadosPorFiltro(filtro: AlarmeFiltro): Observable<any> {
    return this.http.post(this.url + 'AlarmeAtuado/BuscarPorFiltroAlarmeAtuado', filtro, httpOptions);
  }

  public BuscarOcorrenciasAlarmesAtuados(numeroOcorrencias: number): Observable<any>{
    return this.http.get(this.url + 'AlarmeAtuado/BuscarAlarmesMaisAtuados/' + numeroOcorrencias, httpOptions);
  }

}
