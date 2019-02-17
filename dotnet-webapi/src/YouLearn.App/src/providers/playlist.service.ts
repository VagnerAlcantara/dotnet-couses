import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { UtilService } from './util.services';


@Injectable()
export class PlayListService {

  constructor(public http: Http, public utilService: UtilService,) { }
  
  listar(): Promise<Response> {
    let host = this.utilService.obterHostDaApi();

    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', 'Bearer ' + localStorage.getItem('YouLearnToken'));

    return this.http.get(host + 'api/v1/PlayList/Listar/', { headers: headers }).toPromise();
  }

  adicionar(nome: string): Promise<Response> {

    let host = this.utilService.obterHostDaApi();

    let headers : any = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', 'Bearer ' + localStorage.getItem('YouLearnToken'));

    return this.http.post(host + 'api/v1/PlayList/Adicionar/',  {nome: nome}, { headers: headers }).toPromise();
  }

  excluir(id : any): Promise<Response> {

    let host = this.utilService.obterHostDaApi();

    let headers : any = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Authorization', 'Bearer ' + localStorage.getItem('YouLearnToken'));

    return this.http.delete(host + 'api/v1/PlayList/Excluir/' + id, { headers: headers }).toPromise();
  }
}
  