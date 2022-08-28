import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usuario } from './usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioApi {

  private readonly apiBaseUrl = 'http://localhost:44416';

  constructor(private http: HttpClient) { }
 
  getTodos() {
    return this.http.get<Usuario[]>(`${this.apiBaseUrl}/usuario`).toPromise();
  }

  criar(usuario: Usuario) {
    debugger;
    return this.http.post<Usuario>(`${this.apiBaseUrl}/usuario`, usuario).toPromise();
  }

  remover(idUsuario: number | undefined) {
    return this.http.delete(`${this.apiBaseUrl}/usuario/${idUsuario}`).toPromise();
  }

  atualizar(idUsuario: number, usuario: Usuario) {
    return this.http.put<Usuario>(`${this.apiBaseUrl}/usuario/${idUsuario}`, {usuario}).toPromise();
  }
}