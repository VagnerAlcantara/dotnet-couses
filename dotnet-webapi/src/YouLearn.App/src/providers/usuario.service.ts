import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { UtilService } from './util.services';

@Injectable()
export class UsuarioService {

    constructor(
        public http: Http,
        public utilService: UtilService) {

    }

    autenticar(request: any): Promise<Response> {
        let host = this.utilService.obterHostDaApi();

        let headers: any = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(host + 'api/v1/Usuario/Autenticar', request, headers).toPromise();
    }

    adicionar(form: any): Promise<Response> {
        console.log('form', form);

        let host = this.utilService.obterHostDaApi();

        let headers: any = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post(host + 'api/v1/Usuario/Adicionar', form, { headers: headers }).toPromise();
    }
}