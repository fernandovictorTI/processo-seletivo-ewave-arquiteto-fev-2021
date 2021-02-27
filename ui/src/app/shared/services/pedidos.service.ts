import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Pedido, ProdutoPedido } from 'src/app/pedidos/shared/pedido';

@Injectable()
export class PedidosService {
  protected URL = `${environment.apiUrl}pedidos`;

  constructor(protected http: HttpClient) {
  }

  public obterPorId(id: any): Observable<Pedido> {
    return this.http.get<Pedido>(`${this.URL}/${id}`);
  }

  public obter(quantidade): Observable<Pedido[]> {
    return this.http.get<Pedido[]>(`${this.URL}?quantidade=${quantidade}`);
  }

  public criar(data: Pedido): Observable<Pedido> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post<Pedido>(this.URL, data, { headers });
  }

  public adicionarProdutoPedido(idPedido: string, data: ProdutoPedido): Observable<string> {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post<string>(`${this.URL}/${idPedido}/produtos`, data, { headers });
  }

  public removerProdutoPedido(idPedido: string, idProdutoPedido: string): Observable<any> {
    return this.http.delete(`${this.URL}/${idPedido}/produtos/${idProdutoPedido}`);
  }

  public alterarSituacaoPedido(idPedido: string, situacao: number) {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    const data = {
      idPedido: idPedido,
      situacao: +situacao
    };

    return this.http.put<string>(`${this.URL}/${idPedido}/alterar-situacao`, data, { headers });
  }
}
