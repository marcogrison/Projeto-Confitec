import { NgModule } from '@angular/core';
import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UsuarioComponent } from './usuario.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { UsuarioAdicionarComponent } from './adicionar-usuario/adicionar-usuario.component';
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
    UsuarioAdicionarComponent,
    RemoverUsuarioComponent,
  ],
  entryComponents: [UsuarioAdicionarComponent, 
    RemoverUsuarioComponent
  ]
})
export class UsuarioModule { }