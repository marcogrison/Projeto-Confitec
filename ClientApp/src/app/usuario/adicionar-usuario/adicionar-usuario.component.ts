import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { UsuarioService } from '../usuario.service';
import { Usuario } from '../usuario.model';

@Component({
  selector: 'app-adicionar-usuario',
  templateUrl: './adicionar-usuario.component.html',
  styleUrls: ['./adicionar-usuario.component.scss']
})
export class AdicionarUsuarioComponent implements OnInit {

  @Input() usuario : any;
  @Input() titulo: any;
  form!: FormGroup;

  constructor(public modal: NgbActiveModal,
    private formBuilder: FormBuilder,
    public usuarioService: UsuarioService) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      nomeUsuario: [ this.usuario ? this.usuario.nome : null, Validators.required],
      sobrenomeUsuario: [this.usuario ? this.usuario.sobrenome : null, Validators.required],
      emailUsuario: [this.usuario ? this.usuario.email : null , [Validators.required, Validators.email]],
      nivelEscolarId: [this.usuario ? this.usuario.escolaridade : null, Validators.required],
      dataNascimento: [this.usuario ? this.usuario.dataNascimento : null, [Validators.required,this.validaDataDeNascimento ]]
    });
  }

  validaDataDeNascimento(c: AbstractControl){
      return  new Date(c.value).getTime() < new Date(Date.now()).getTime() ? null : { datainvalida :true } ;
  }

  save(){
    debugger;
      this.usuarioService.salvar({
      idUsuario: this.usuario ? this.usuario.idUsuario : null,
      nomeUsuario: this.form.get('nomeUsuario')?.value,
      sobrenomeUsuario: this.form.get('sobrenomeUsuario')?.value,
      emailUsuario: this.form.get('emailUsuario')?.value,
      nivelEscolarId: parseInt(this.form.get('nivelEscolarId')?.value) ,
      dataNascimento: this.form.get('dataNascimento')?.value
      });
      this.modal.close();
  }

  validaTouchedValido(field: string | (string | number)[]){
    return !this.form.get(field)?.valid && this.form.get(field)?.touched;
  }

  addCssError(field: any){
    return {
      'is-invalid' : this.validaTouchedValido(field)
    }
  }

}
