import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-remover-usuario',
  templateUrl: './remover-usuario.component.html',
  styleUrls: ['./remover-usuario.component.scss']
})
export class RemoverUsuarioComponent implements OnInit {

  @Input() usuario: any;
  constructor(public modal: NgbActiveModal,
    public usuarioService: UsuarioService) { }

  ngOnInit() {
  }

  remove(){
    this.usuarioService.deletar(this.usuario);
    this.modal.close();
  }

}
