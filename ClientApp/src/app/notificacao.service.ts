import { Injectable } from '@angular/core';
  
import { ToastrService } from 'ngx-toastr';
  
@Injectable({
  providedIn: 'root'
})
export class NotificacaoService {
  
  constructor(private toastr: ToastrService) { }
  
  msgSucesso(mensagem: any , titulo: any){
      this.toastr.success(mensagem, titulo)
  }
  
  msgErro(mensagem: any, titulo: any){
      this.toastr.error(mensagem, titulo)
  }
  
  msgInfo(mensagem: any, titulo: any){
      this.toastr.info(mensagem, titulo)
  }
  
  msgAviso(mensagem: any, titulo: any){
      this.toastr.warning(mensagem, titulo)
  }
  
}