import { EnvironmentBase } from './environment.base';

class Environment extends EnvironmentBase {
  public production: boolean;

  constructor() {
    super();
    this.production = true;
  }
}

export const environment = new Environment();
