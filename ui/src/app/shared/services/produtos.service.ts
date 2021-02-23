import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Produto } from 'src/app/produtos/shared/produto';
import { environment } from 'src/environments/environment';

@Injectable()
export class ProdutosService {
  protected URL = `${environment.apiUrl}produtos`;

  constructor(protected http: HttpClient) {
  }

  public obterPorId(id: any): Observable<Produto> {
    return this.http.get<Produto>(`${this.URL}/${id}`);
  }

  public obter(quantidade): Observable<Produto[]> {
    return this.http.get<Produto[]>(`${this.URL}?quantidade=${quantidade}`);
  }

  public obterLovs(): Observable<Produto[]> {
    return this.http.get<Produto[]>(`${this.URL}?quantidade=100`);
  }

  public criar(data: Produto): Observable<Produto> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post<Produto>(this.URL, data, {headers});
  }
}
