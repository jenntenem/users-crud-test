import { EnvironmentBase } from './environment.base';

class Environment extends EnvironmentBase {
  public production: boolean;

  constructor() {
    super();
    this.production = false;
  }
}

export const environment = new Environment();
