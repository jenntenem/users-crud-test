import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Departamento } from '@users/models/user.model';

@Injectable({
  providedIn: 'root',
})
export class DepartmentsService {
  service: string = 'departamentos';
  ip = String;

  constructor(@Inject('env') private env, private httpClient: HttpClient) {
    const { config } = this.env;
    this.ip = config.ip;
  }

  public getAllDepartments() {
    const url = `${this.ip}/${this.service}`;
    return this.httpClient.get(url);
  }

  public getDepartmentById(id: number) {
    const url = `${this.ip}/${this.service}/${id}`;
    return this.httpClient.get(url);
  }

  public createDepartment(body: Departamento) {
    const url = `${this.ip}/${this.service}`;
    return this.httpClient.post(url, body);
  }

  public updateDepartment(id: number, body: Departamento) {
    const url = `${this.ip}/${this.service}/${id}`;
    return this.httpClient.put(url, body);
  }

  public deleteDepartment(id: number) {
    const url = `${this.ip}/${this.service}/${id}`;
    return this.httpClient.delete(url);
  }
}
