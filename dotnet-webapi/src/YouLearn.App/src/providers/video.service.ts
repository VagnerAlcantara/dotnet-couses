import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import { UtilService } from './util.services';


@Injectable()
export class VideoService {

    constructor(public http: Http, public utilService: UtilService,
    ) { }

    listarPorTags(tags: string): Promise<Response> {

        let host = this.utilService.obterHostDaApi();

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.get(host + 'api/v1/Video/Listar/' + tags, { headers: headers }).toPromise();
    }

    listarPorPlayList(idPlayList: string): Promise<Response> {
        let host = this.utilService.obterHostDaApi();

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.get(host + 'api/v1/Video/Listar/' + idPlayList, { headers: headers }).toPromise();
    }

    adicionar(request: any): Promise<Response> {

        let host = this.utilService.obterHostDaApi();

        let headers: any = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Authorization', 'Bearer ' + localStorage.getItem('YouLearnToken'));

        return this.http.post(host + 'api/v1/Video/Adicionar/', request, { headers: headers }).toPromise();
    }
}
