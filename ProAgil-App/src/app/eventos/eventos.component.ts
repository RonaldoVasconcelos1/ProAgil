import { Component, OnInit } from '@angular/core';
import { Evento } from '../_models/Evento';
import { EventoService } from '../_services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  get filtroLista(): string {
      return this._filtroLista;
  }
  set filtroLista( value: string) {
    this._filtroLista = value;
    // IF ternario de uma linha
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this._filtroLista) : this.eventos;
  }

  constructor(private eventoService: EventoService) { }

  // tslint:disable-next-line: variable-name
  _filtroLista  = '';
  eventosFiltrados: Evento[];
  eventos: Evento[];
  imagemLargura = 50;
  imagemMargem = 2;
  mostarImagem = false;

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return  this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );

  }

  ngOnInit() {
    this.getEventos();
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
  alternarImagenm() {
    this.mostarImagem = !this.mostarImagem;
  }
}

