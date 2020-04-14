import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../_models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

constructor(private http: HttpClient) { }

  BaseURL = 'http://localhost:5000/api/evento';

  getAllEventos(): Observable<Evento[]> {

    return this.http.get<Evento[]>(this.BaseURL);
  }
  getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.BaseURL}/getByTema/${tema}`);
  }
  getEventosById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.BaseURL}/${id}`);
  }

  postEvento(evento: Evento) {
    return this.http.post(this.BaseURL, evento);
  }
  putEvento(evento: Evento) {
    return this.http.put(`${this.BaseURL}/${evento.id}`, evento);
  }
  deleteEvento(id: number) {
    return this.http.delete(`${this.BaseURL}/${id}`);
  }
}
