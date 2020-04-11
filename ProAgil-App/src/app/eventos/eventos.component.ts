import { Component, OnInit, TemplateRef } from '@angular/core';
import { Evento } from '../_models/Evento';
import { EventoService } from '../_services/evento.service';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  // tslint:disable-next-line: variable-name
  _filtroLista  = '';
  eventosFiltrados: Evento[];
  eventos: Evento[];
  imagemLargura = 50;
  imagemMargem = 2;
  mostarImagem = false;
  modalRef: BsModalRef;
  registerForm: FormGroup;
  maxPessoas = 12000;

  constructor(private eventoService: EventoService, private modalService: BsModalService) { }

  get filtroLista(): string {
    return this._filtroLista;
  }
  set filtroLista( value: string) {
    this._filtroLista = value;
    // IF ternario de uma linha
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this._filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return  this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
}

  ngOnInit() {
      this.validation();
      this.getEventos();
}
salvarAlteracao() {

}
validation() {
  this.registerForm = new FormGroup({
    tema: new FormControl('',
     [Validators.required, Validators.minLength(4), Validators.maxLength(60)]),
    local: new FormControl('', Validators.required),
    dataEvento: new FormControl('', Validators.required),
    imagemURL: new FormControl('', Validators.required),
    qtdPessoas: new FormControl('',
    [Validators.required, Validators.max(120000)]),
    telefone: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email])
  });
}

  getEventos() {
    this.eventoService.getAllEventos().subscribe(
      (evento: Evento[]) => {
     this.eventos = evento;
     this.eventosFiltrados = this.eventos;
     console.log(evento);
  }, error => {
    console.log(error);
  });
}
  alternarImagem() {
    this.mostarImagem = !this.mostarImagem;
}
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}

