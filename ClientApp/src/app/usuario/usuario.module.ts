import { NgModule } from '@angular/core';
import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UsuarioComponent } from './usuario.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { AdicionarUsuarioComponent } from './adicionar-usuario/adicionar-usuario.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RemoverUsuarioComponent } from './remover-usuario/remover-usuario.component';


@NgModule({
  imports: [
    NgbModalModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule
   
  ],
  declarations: [
    UsuarioComponent,
    AdicionarUsuarioComponent,
    RemoverUsuarioComponent,
  ],
  entryComponents: [AdicionarUsuarioComponent, 
    RemoverUsuarioComponent
  ]
})
export class UsuarioModule { }