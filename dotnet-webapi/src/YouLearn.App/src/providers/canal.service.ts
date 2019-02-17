import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { UtilService } from './util.services';


@Injectable()
export class CanalService {

  constructor(public http: Http, public utilService: UtilService,) { }
  
  listar(): Promise<Response> {
    let host = this.utilService.obterHostDaApi();

    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', 'Bearer ' + localStorage.getItem('YouLearnToken'));

    return this.http.get(host + 'api/v1/Canal/Listar/', { headers: headers }).toPromise();
  }

  adicionar(nome: string, urlLogo: string): Promise<Response> {

    let host = this.utilService.obterHostDaApi();

    let headers : any = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', 'Bearer ' + localStorage.getItem('YouLearnToken'));

    return this.http.post(host + 'api/v1/Canal/Adicionar/',  {nome: nome, urlLogo : urlLogo}, { headers: headers }).toPromise();
  }

  excluir(id : any): Promise<Response> {

    let host = this.utilService.obterHostDaApi();

    let headers : any = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', 'Bearer ' + localStorage.getItem('YouLearnToken'));

    return this.http.delete(host + 'api/v1/Canal/Excluir/' + id, { headers: headers }).toPromise();
  }
}
  