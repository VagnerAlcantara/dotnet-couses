import { Component } from '@angular/core';
import { IonicPage, NavController } from 'ionic-angular';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { UtilService } from '../../providers/util.services';
import { UsuarioService } from '../../providers/usuario.service';

@IonicPage()
@Component({
  selector: 'page-novo-usuario',
  templateUrl: 'novo-usuario.html',
})
export class NovoUsuarioPage {

  public form: FormGroup;
  constructor(
    private fb: FormBuilder,
    private utilService: UtilService,
    private usuarioService: UsuarioService,
    private navCtrl: NavController) {

    this.form = this.fb.group({
      primeiroNome: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(50),
        Validators.required
      ])],
      segundoNome: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(50),
        Validators.required
      ])],
      email: ['', Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(150),
        Validators.required
      ])],
      senha: ['', Validators.compose([
        Validators.minLength(5),
        Validators.maxLength(36),
        Validators.required
      ])],

    });
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad NovoUsuarioPage');
  }

  salvar() {
    let loading = this.utilService.showLoading();
    loading.present();
    console.log(this.form.value);
    this.usuarioService.adicionar(this.form.value)
      .then((response) => {

        console.log(response.json());
        loading.dismiss();

        this.utilService.showAlert('Operação realizada com sucesso!');

        localStorage.setItem('usuario.email', this.form.value.email);

        this.navCtrl.pop();
      })
      .catch((response) => {
        loading.dismiss();
        this.utilService.showMessageError(response);
      });
  }

  cancelar() {
    this.navCtrl.pop();
  }
}
