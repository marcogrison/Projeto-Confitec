import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usuario } from './usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UserApi {

  private readonly apiBaseUrl = ' http://localhost:44416';

  constructor(private http: HttpClient) { }

  getTodos() {
    return this.http.get<Usuario[]>(`${this.apiBaseUrl}/usuario`).toPromise();
  }

  criar(usuario: Usuario) {
    return this.http.post<Usuario>(`${this.apiBaseUrl}/usuario`, usuario).toPromise();
  }

  remover(idUsuario: number) {
    return this.http.delete(`${this.apiBaseUrl}/Usuario/${idUsuario}`).toPromise();
  }

  atualizar(idUsuario: number, usuario: Usuario) {
    return this.http.put<Usuario>(`${this.apiBaseUrl}/user/${idUsuario}`, {usuario}).toPromise();
  }
}