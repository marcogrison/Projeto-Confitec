import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { UserService } from './user.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddUserComponent } from './add-user/add-user.component';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { UserRemoveComponent } from './user-remove/user-remove.component';
import { Usuario } from './user.model';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UsuarioComponent implements OnInit {

  niveisEscolares = [{"id": 1, "descricao": "Infantil"},
  {"id": 2, "descricao": "Fundamental"},
  {"id": 3, "descricao": "Médio"},
  {"id": 4, "descricao": "Superior"}
  ];

  usersTrackFn = (i, user) => user.id;

  constructor(public userService: UserService,
    private modalService: NgbModal
    ) { }

  ngOnInit() {
    
  }


  public incluir(){
    const modalRef = this.modalService.open(AddUserComponent);
    modalRef.componentInstance.title = 'Incluir';
  }

  public modificar(usuario: Usuario){
    const modalRef = this.modalService.open(AddUserComponent);
     modalRef.componentInstance.title = 'Alterar';
     modalRef.componentInstance.user = user;
  }

  public excluir(user: User){
    console.log(user);
    const modalRef = this.modalService.open(UserRemoveComponent);
    modalRef.componentInstance.user = user;
  }

  findGrade(id: number) : string{
    const degree = this.degrees.find(d => d.id === id);
    return degree ? degree.descricao : null;
  }

}
