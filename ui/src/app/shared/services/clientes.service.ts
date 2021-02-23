import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Cliente } from 'src/app/clientes/shared/cliente';
import { environment } from '../../../environments/environment';

@Injectable()
export class ClientesService {
  protected URL = `${environment.apiUrl}clientes`;

  constructor(protected http: HttpClient) {
  }

  public obterPorId(id: any): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.URL}/${id}`);
  }

  public obter(quantidade): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${this.URL}?quantidade=${quantidade}`);
  }

  public obterLovs(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${this.URL}?quantidade=100`);
  }

  public criar(data: Cliente): Observable<Cliente> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post<Cliente>(this.URL, data, {headers});
  }
}
