export enum TipoModificador {
  Crear = "Crear",
  Editar = "Editar",
  Eliminar = "Eliminar",
}

export interface UsuarioBase {
  id?: number;
  usuario: string;
  primerNombre: string;
  segundoNombre?: string;
  primerApellido: string;
  segundoApellido?: string;
  email?: string;
  idDepartamento: number;
  idCargo: number;
  activo: boolean;
}

export interface Usuario extends UsuarioBase {
  nombres?: string;
  apellidos?: string;
  cargo?: string;
  departamento?: string;
}

interface Administracion {
  id: number;
  codigo: string;
  nombre: string;
  activo: boolean;
  idUsuarioCreacion: number;
}

export interface Departamento extends Administracion {}

export interface Cargo extends Administracion {}
