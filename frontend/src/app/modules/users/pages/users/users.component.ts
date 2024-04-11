import { Component } from '@angular/core';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
})
export class UsersComponent {
  cols: any[];
  users!: any[];
  user!: any;
  selectedUsers!: any[] | null;
  showUserDialog: boolean = false;

  constructor() {}

  ngOnInit() {
    this.loadUserDataTable();
  }

  loadUserDataTable(): void {
    this.cols = [
      { header: 'Usuario', field: 'usuario' },
      { header: 'Nombres', field: 'nombres' },
      { header: 'Apellidos', field: 'apellidos' },
      { header: 'Departamento', field: 'departamento' },
      { header: 'Cargo', field: 'cargo' },
      { header: 'Email', field: 'email' },
      { header: 'Acciones', field: 'acciones' },
    ];

    this.users = [
      {
        usuario: 'asdas',
      },
    ];
  }

  openNew() {}

  deleteSelectedProducts() {}

  editUser(user) {}
  deleteUser(user) {}
}
