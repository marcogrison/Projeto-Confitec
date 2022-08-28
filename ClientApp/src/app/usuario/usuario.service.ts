import { Injectable } from '@angular/core';
import { UsuarioApi } from './usuario.api';
import { UsuarioSituacao } from './usuario.situacao';
import { Observable } from 'rxjs';
import { Usuario } from './usuario.model';
import { NotificacaoService } from '../notificacao.service';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  constructor(
    private api: UsuarioApi,
    private situacao: UsuarioSituacao,
    private notificacaoService: NotificacaoService
  ) {
    this.loadAll();
  }

  async loadAll() {
    this.situacao.usuarios = await this.api.getTodos();
  }

  get usuarios$(): Observable<Usuario[]> {
    return this.situacao.usuarios$;
  }

  public async deletar(usuario: Usuario) {
    const usuarioAnterior = this.situacao.getPorId(usuario.idUsuario);

    try {
      await this.api.remover(usuario.idUsuario);
      this.situacao.deletarUsuario(usuario.idUsuario);
      this.notificacaoService.msgSucesso('Excluído com Sucesso!', 'SUCESSO');
    } catch (error) {
      this.notificacaoService.msgErro('Não foi possível excluir', 'ERRO');
      this.situacao.adicionarUsuario(usuarioAnterior!);
    }
  }

  public async salvar(usuario: Usuario) {
    debugger;
    if (usuario.idUsuario) {
      this.atualizar(usuario);
    } else {
      this.adicionar(usuario);
    }
  }

  private async atualizar(usuario: Usuario) {
    const usuarioAnterior = this.situacao.getPorId(usuario.idUsuario);
    this.situacao.atualizar(usuario);

    try {
      await this.api.atualizar(usuario.idUsuario!, usuario);
      this.notificacaoService.msgSucesso('Alterado com Sucesso!', 'SUCESSO');
    } catch (error) {
      this.notificacaoService.msgErro('Não foi possível alterar', 'ERRO');
      this.situacao.atualizar(usuarioAnterior!);
    }
  }

  private async adicionar(usuario: Usuario) {
    try {
      const usuarioJaCriado = await this.api.criar(usuario);
      this.situacao.adicionarUsuario(usuarioJaCriado);
      this.notificacaoService.msgSucesso('Adicionado com Sucesso!', 'SUCESSO');
    } catch (error) {
      this.notificacaoService.msgErro('Não foi possível adicionar', 'ERRO');
      this.situacao.deletarUsuario(usuario.idUsuario);
    }
  }
}

