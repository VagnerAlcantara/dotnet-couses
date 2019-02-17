import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, ModalController } from 'ionic-angular';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { CanalService } from '../../providers/canal.service';
import { PlayListService } from '../../providers/playlist.service';
import { VideoService } from '../../providers/video.service';
import { UtilService } from '../../providers/util.services';

@IonicPage()
@Component({
  selector: 'page-video',
  templateUrl: 'video.html',
})
export class VideoPage {

  form: FormGroup;
  canais: any[] = [];
  playlists: any[] = [];

  constructor(public navCtrl: NavController,
    public navParams: NavParams,
    private fb: FormBuilder,
    private utilService: UtilService,
    private modalCtrl: ModalController,
    private canalService: CanalService,
    private playListService: PlayListService,
  private videoService : VideoService) {

    this.form = this.fb.group({
      titulo: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(100),
        Validators.required
      ])],
      descricao: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(255),
        Validators.required
      ])],
      idVideoYoutube: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(30),
        Validators.required
      ])],
      tags: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(150),
        Validators.required
      ])],

      idCanal: ['', Validators.compose([
        Validators.required
      ])],

      idPlaylist: ['', Validators.compose([

      ])],

      ordemNaPlayList: ['', Validators.compose([


      ])],
    });
  }

  ionViewDidLoad() {
    this.loadCanal();
    this.loadPlayList();
  }

  loadCanal() {

    //Abre tela de aguarde
    let loading = this.utilService.showLoading();
    loading.present();

    this.canalService.listar().then((response) => {
      this.canais = response.json();

      //Fecha a tela de aguarde
      loading.dismiss();

    }).catch((response) => {

      loading.dismiss();

      this.utilService.showMessageError(response);

    });
  }

  loadPlayList() {
    //Abre tela de aguarde
    let loading = this.utilService.showLoading();
    loading.present();

    this.playListService.listar().then((response) => {
      this.playlists = response.json();

      //Fecha a tela de aguarde
      loading.dismiss();

    }).catch((response) => {

      loading.dismiss();

      this.utilService.showMessageError(response);

    });
  }

  salvar() {
    console.log(this.form.value);
    //Abre tela de aguarde
    let loading = this.utilService.showLoading();
    loading.present();

    this.videoService.adicionar(this.form.value).then((response)=>{
      //Fecha a tela de aguarde
      loading.dismiss();

      this.utilService.showAlert("Operação realizada com sucesso!");
      this.navCtrl.pop();

    }).catch((response)=>{
      loading.dismiss();
      this.utilService.showMessageError(response);
    });

  }

  cancelar() {
    this.navCtrl.pop();
  }

  showAddCanal() {
    let modal = this.modalCtrl.create('AdicionarCanalPage');

    modal.onDidDismiss(data => {
      this.loadCanal();
    });

    modal.present();
  }

  showAddPlayList() {
    let modal = this.modalCtrl.create('AdicionarPlayListPage');

    modal.onDidDismiss(data => {
      this.loadPlayList();
    });

    modal.present();
  }

}
