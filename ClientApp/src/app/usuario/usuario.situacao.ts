import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Usuario} from './usuario.model';

@Injectable({ providedIn: 'root' })
export class UsuarioSituacao {

    private readonly _usuarios = new BehaviorSubject<Usuario[]>([]);

    public get usuarios$(): Observable<Usuario[]> {
        return this._usuarios.asObservable();
    }

    set usuarios(val: Usuario[]) {
        this._usuarios.next(val);
    }

    get usuarios(): Usuario[] {
        return this._usuarios.getValue();
      }
    
    public getPorId(id: number | undefined): Usuario | undefined {
        return this.usuarios.find(u => u.idUsuario === id);
    }

    public atualizar(usuarioAtualizado: Usuario ) {
        const user = this.getPorId(usuarioAtualizado.idUsuario);
    
        if (user) {
          const index = this.usuarios.indexOf(user);
    
          this.usuarios[index] = usuarioAtualizado;
    
          this.usuarios = [...this.usuarios];
        }
      }

      public adicionarUsuario(usuario: Usuario) {
        const currentValue = this.usuarios;
        this.usuarios = [ ...currentValue, usuario ];
      }

      public deletarUsuario(id: number | undefined) {
        this.usuarios = this.usuarios.filter(u => u.idUsuario !== id);
      }

}