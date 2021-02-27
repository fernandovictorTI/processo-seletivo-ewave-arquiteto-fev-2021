import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Garcom } from '../../garcons/shared/garcom';
import { environment } from 'src/environments/environment';

@Injectable()
export class GarconsService {
  protected URL = `${environment.apiUrl}garcons`;

  constructor(protected http: HttpClient) {
  }

  public obterPorId(id: any): Observable<Garcom> {
    return this.http.get<Garcom>(`${this.URL}/${id}`);
  }

  public obter(quantidade): Observable<Garcom[]> {
    return this.http.get<Garcom[]>(`${this.URL}?quantidade=${quantidade}`);
  }

  public obterLovs(): Observable<Garcom[]> {
    return this.http.get<Garcom[]>(`${this.URL}?quantidade=100`);
  }

  public criar(data: Garcom): Observable<Garcom> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post<Garcom>(this.URL, data, { headers });
  }
}
