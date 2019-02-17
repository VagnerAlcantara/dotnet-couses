import { Component } from '@angular/core';
import { NavController, AlertController } from 'ionic-angular';
import { VideoService } from '../../providers/video.service';
import { UsuarioService } from '../../providers/usuario.service';
import { UtilService } from '../../providers/util.services';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  videos: any[] = [];
  constructor(public navCtrl: NavController,
    private utilService: UtilService,
    private videoService: VideoService,
    private alertCtrl: AlertController,
    private usuarioService: UsuarioService) {
  }

  buscarVideo(tag: string) {
    console.log(tag);

    if (tag == null || tag.trim() == '') {
      return;
    }

    //Chama a api e obtenho os videos
    this.loadVideos(tag);
  }

  loadVideos(tag: string) {
    //Abri a tela de aguarde
    let loading = this.utilService.showLoading();
    loading.present();

    //Chamei a API
    this.videoService.listarPorTags(tag).then((response) => {
      //Populo minhas lista de videos em um array
      this.videos = response.json();

      console.log(this.videos);

      //Fecho a tela de aguarde
      loading.dismiss();

    }).catch((response) => {

      this.utilService.showMessageError(response);
    });
  }

  showNovoVideo() {
    let token = localStorage.getItem('YouLearnToken');

    if (token != null) {
      //Se estiver autenticado, libera para tela de cadastro de videos
      this.navCtrl.push('VideoPage');
    }
    else {
      let prompt = this.alertCtrl.create({
        title: 'Autenticar',
        message: 'Informe seus dados para se autenticar no sistema',
        inputs: [
          {
            name: 'email',
            placeholder: 'E-mail',
            type: 'email',
            value: localStorage.getItem('usuario.email')
          },
          {
            name: 'senha',
            placeholder: 'Senha',
            type: 'password'
          }
        ],
        buttons: [
          {
            text: 'Novo usuário',
            handler: () => {
              this.navCtrl.push('NovoUsuarioPage');
            }
          },
          {
            text: 'Entrar',
            handler: (data) => {
              this.autenticarUsuario(data);
            }
          }
        ]
      });

      prompt.present();
    }
  }

  autenticarUsuario(request: any) {
    //Abre a tela de aguarde
    let loading = this.utilService.showLoading('Autenticando...');
    loading.present();

    this.usuarioService.autenticar(request)
      .then((response) => {
        let autenticado : boolean = response.json().authenticated;
        
        if (autenticado == false){
          this.utilService.showToast("E-mail ou senha inválidos!")
          loading.dismiss();
          return;
        }

        let token: string = response.json().accessToken;
        let primeiroNome: string = response.json().primeiroNome;

        //salva no local storage
        localStorage.setItem('YouLearnToken', token);

        loading.dismiss();

        let confirm = this.alertCtrl.create({
          title: 'Oi ' + primeiroNome,
          message: 'Deseja criar um novo vídeo?',
          buttons: [
            {
              text: 'Não',
              handler: () => { }
            },
            {
              text: 'Sim, eu quero',
              handler: () => {
                this.navCtrl.push('VideoPage');
              }
            },
          ]
        });

        confirm.present();

      })
      .catch((response)=>{
        loading.dismiss();
        this.utilService.showMessageError(response);
      });
  }

  compartilharFacebook(video){
    window.open('https://www.facebook.com/sharer.php?u=' + video.url);
  }

  showPlayList(video : any){
    this.navCtrl.push('PlayListPage', {idPlayList: video.idPlayList, nomePlayList: video.nomePlayList});
  }

  playVideo(video : any){
    this.navCtrl.push('PlayVideoPage', {url: video.url});
  }
}
