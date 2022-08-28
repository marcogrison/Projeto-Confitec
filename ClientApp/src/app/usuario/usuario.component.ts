import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { UsuarioService } from './usuario.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AdicionarUsuarioComponent } from './adicionar-usuario/adicionar-usuario.component';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { RemoverUsuarioComponent } from './remover-usuario/remover-usuario.component';
import { Usuario } from './usuario.model';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UsuarioComponent implements OnInit {
  niveisEscolares = [
    { id: 1, descricao: 'Infantil' },
    { id: 2, descricao: 'Fundamental' },
    { id: 3, descricao: 'Médio' },
    { id: 4, descricao: 'Superior' },
  ];

  trackporUsuario = (index: number, item: Usuario) => item.idUsuario;

  constructor(
    public usuarioService: UsuarioService,
    private modalService: NgbModal
  ) {}

  ngOnInit() {}

  public inserir() {
    const modalRef = this.modalService.open(AdicionarUsuarioComponent);
    modalRef.componentInstance.title = 'Inserir';
  }

  public modificar(usuario: Usuario) {
    const modalRef = this.modalService.open(AdicionarUsuarioComponent);
    modalRef.componentInstance.title = 'Alterar';
    modalRef.componentInstance.usuario = usuario;
  }

  public excluir(usuario: Usuario) {
    const modalRef = this.modalService.open(RemoverUsuarioComponent);
    modalRef.componentInstance.usuario = usuario;
  }

  procurarNivelEscolar(id: number): string {
    const nivel = this.niveisEscolares.find((d) => d.id === id);

    if (nivel) return nivel.descricao;
    else return '';
  }
}
