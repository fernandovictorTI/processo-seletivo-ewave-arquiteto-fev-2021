import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Comanda} from '../../comandas/shared/comanda';
import { Cozinha } from 'src/app/cozinha/shared/cozinha';
import { environment } from 'src/environments/environment';

@Injectable()
export class ComandasService {
  protected URL = `${environment.apiUrl}comandas`;

  constructor(protected http: HttpClient) {
  }

  public obterPorId(id: any): Observable<Comanda> {
    return this.http.get<Comanda>(`${this.URL}/${id}`);
  }

  public obter(quantidade): Observable<Comanda[]> {
    return this.http.get<Comanda[]>(`${this.URL}?quantidade=${quantidade}`);
  }

  public obterComandasAbertas(): Observable<Cozinha[]> {
    return this.http.get<Cozinha[]>(`${this.URL}/abertas`);
  }

  public obterLovs(): Observable<Comanda[]> {
    return this.http.get<Comanda[]>(`${this.URL}?quantidade=100`);
  }

  public criar(data: Comanda): Observable<Comanda> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post<Comanda>(this.URL, data, {headers});
  }
}
