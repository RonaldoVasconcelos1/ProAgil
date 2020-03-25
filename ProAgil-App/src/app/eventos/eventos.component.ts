import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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



  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: variable-name
  _filtroLista: string;
eventosFiltrados: any = [];
eventos: any = [];
imagemLargura = 50;
imagemMargem = 2;
mostarImagem = false;

  filtrarEventos(filtrarPor: string) {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return  this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );

  }

  ngOnInit() {
    this.getEventos();
  }
  getEventos() {
    this.http.get('http://localhost:5000/api/values').subscribe(
   Response => {
     this.eventos = Response;
     console.log();
  }, error => {
     console.log(error);
  });
  }
  alternarImagenm() {
    this.mostarImagem = !this.mostarImagem;
  }
}

