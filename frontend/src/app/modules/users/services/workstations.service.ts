import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Cargo } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class WorkstationsService {
  service: string = 'cargos';
  ip = String;

  constructor(@Inject('env') private env, private httpClient: HttpClient) {
    const { config } = this.env;
    this.ip = config.ip;
  }

  public getAllWorkStations() {
    const url = `${this.ip}/${this.service}`;
    return this.httpClient.get(url);
  }

  public getWorkStationById(id: number) {
    const url = `${this.ip}/${this.service}/${id}`;
    return this.httpClient.get(url);
  }

  public createWorkStation(body: Cargo) {
    const url = `${this.ip}/${this.service}`;
    return this.httpClient.post(url, body);
  }

  public updateWorkStation(id: number, body: Cargo) {
    const url = `${this.ip}/${this.service}/${id}`;
    return this.httpClient.put(url, body);
  }

  public deleteWorkStation(id: number) {
    const url = `${this.ip}/${this.service}/${id}`;
    return this.httpClient.delete(url);
  }
}
