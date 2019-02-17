import { Component } from '@angular/core';
import { IonicPage, ViewController, AlertController } from 'ionic-angular';
import { PlayListService } from '../../providers/playlist.service';
import { UtilService } from '../../providers/util.services';

@IonicPage()
@Component({
  selector: 'page-adicionar-play-list',
  templateUrl: 'adicionar-play-list.html',
})
export class AdicionarPlayListPage {

  playLists: any[] = [];
  constructor(
    private viewCtrl: ViewController,
    private utilService: UtilService,
    private playListService: PlayListService,
    private alertCtrl: AlertController
  ) {
  }

  ionViewDidLoad() {
    this.loadPlayList();
  }

  excluir(playlist: any) {
    //Abre tela de aguarde
    let loading = this.utilService.showLoading();
    loading.present();

    this.playListService.excluir(playlist.id).then((response) => {

      this.utilService.showAlert(response.json().mensagem);

      this.loadPlayList();

      //Fecha a tela de aguarde
      loading.dismiss();

    }).catch((response) => {

      loading.dismiss();

      this.utilService.showMessageError(response);

    });
  }

  closeModal() {
    this.viewCtrl.dismiss();
  }

  loadPlayList() {
    //Abre tela de aguarde
    let loading = this.utilService.showLoading();
    loading.present();

    this.playListService.listar().then((response) => {
      this.playLists = response.json();

      //Fecha a tela de aguarde
      loading.dismiss();

    }).catch((response) => {

      loading.dismiss();

      this.utilService.showMessageError(response);

    });
  }

  adicionar() {
    let prompt = this.alertCtrl.create({
      title: 'Adicionar playlist',
      message: "Informe os dados da playlist",
      inputs: [
        {
          name: 'nome',
          placeholder: 'Nome da playlist',
          type: 'text'
        }
      ],
      buttons: [
        {
          text: 'Cancelar',
          handler: data => {

          }
        },
        {
          text: 'Salvar',
          handler: data => {
            //Abre tela de aguarde
            let loading = this.utilService.showLoading();
            loading.present();

            this.playListService.adicionar(data.nome).then((response) => {
              //Fecha a tela de aguarde
              loading.dismiss();

              this.loadPlayList();

            }).catch((response) => {

              loading.dismiss();

              this.utilService.showMessageError(response);

            });
          }
        }
      ]
    });

    prompt.present();
  }
}
