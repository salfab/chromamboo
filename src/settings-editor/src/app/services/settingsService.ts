import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class SettingsService {
    getAll(): any[] {
        const settings = {
            'notifications': [
              {
                'displayName': 'Project-1',
                'provider': 'atlassian-ci',
                'username': 'sio',
                'planKey': 'MET-MCI',
                'bitbucketSettings': {
                  'apiBaseUrl': 'http://url.com',
                  'username': 'sio',
                  'password': '12345',
                  'projectKey': 'MYV',
                  'repoSlug': 'metis'
                },
                'bambooSettings': {
                  'apiBaseUrl': 'http://url.com',
                  'username': 'sio',
                  'password': '12345'
                },
                'trigger': {
                  'provider': 'polling-trigger',
                  'frequence': '30000'
                },
                'presentation': [
                  {
                    'provider': 'razer-chroma',
                    // tslint:disable-next-line:max-line-length
                    'keys': [ 'Num0', 'NumDecimal', 'NumEnter', 'Num1', 'Num2', 'Num3', 'Num4', 'Num5', 'Num6', 'Num7', 'Num8', 'Num9', 'NumLock', 'NumDivide', 'NumMultiply', 'NumSubtract', 'NumAdd' ]
                  },
                  {
                    'provider': 'blync',
                    'selectedBlyncDevice': 0,
                    'numberOfExecutions': 0
                  }
                ]
              },
              {
                'displayName': 'Project-1-PR',
                'provider': 'pull-request',
                'username': 'sio',
                'bitbucketSettings': {
                  'apiBaseUrl': 'http://url.com',
                  'username': 'sio',
                  'password': '12345',
                  'projectKey': 'MYV',
                  'repoSlug': 'metis'
                },
                'trigger': {
                  'provider': 'polling-trigger',
                  'frequence': '30000'
                },
                'presentation': [
                  {
                    'provider': 'razer-chroma',
                    'keys': [ 'Macro1' ]
                  },
                  {
                    'provider': 'blync',
                    'selectedBlyncDevice': 0,
                    'numberOfExecutions': 0
                  }
                ]
              },
              {
                'displayName': 'Project-1-git',
                'provider': 'git',
                'repositoryPath': 'C:\\sources\\metis',
                'trigger':
                 {
                  'message': 'git-push',
                  'provider': 'push-trigger',
                  'url': 'http://url.com'
                },
                'presentation': [
                  {
                    'provider': 'razer-chroma',
                    'keyUncommitted': [ 'Macro2' ],
                    'keyBehindDevelop': [ 'Macro3' ]
                  }
                ]
              }
            ],
            'sharedConfigs': [
              {
                'id': 'bitbucketConfig',
                'settings': {
                  'apiBaseUrl': 'http://url.com',
                  'username': 'sio',
                  'password': '12345',
                  'projectKey': 'MYV',
                  'repoSlug': 'metis'
                }
              }
            ]
          };
        return settings.notifications;
    }
    GetSettings(): Observable<ChromambooSettings> {
        throw new Error('Method not implemented.');
    }

    constructor(/*private httpClient: HttpClient*/) { }
}

