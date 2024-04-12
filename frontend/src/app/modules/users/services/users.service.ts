import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Usuario } from '@users/models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  service: string = 'usuarios';
  ip = String;

  constructor(@Inject('env') private env, private httpClient: HttpClient) {
    const { config } = this.env;
    this.ip = config.ip;
  }

  public getAllUsers() {
    const url = `${this.ip}/${this.service}`;
    return this.httpClient.get(url);
  }

  public getUserById(id: number) {
    const url = `${this.ip}/${this.service}/${id}`;
    return this.httpClient.get(url);
  }

  public createUser(body: Usuario) {
    const url = `${this.ip}/${this.service}`;
    return this.httpClient.post(url, body);
  }

  public updateUser(id: number, body: Usuario) {
    const url = `${this.ip}/${this.service}/${id}`;
    return this.httpClient.put(url, body);
  }

  public deleteUser(id: number) {
    console.log({ id})
    const url = `${this.ip}/${this.service}/${id}`;
    return this.httpClient.delete(url);
  }
}
