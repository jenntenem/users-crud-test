declare var window: any;

export class EnvironmentBase {
  public get config(): any {
    return window.config;
  }
}
