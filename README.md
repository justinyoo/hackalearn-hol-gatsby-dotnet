# HackaLearn 핸즈온 워크샵 with Gatsby & .NET #

2021년 8월 10일 저녁 8시에 진행한 [HackaLearn](https://aka.ms/hackalearn/korea) 부대 행사인 [핸즈온 워크샵](https://youtu.be/x3j3mDblqMY)의 샘플 코드입니다.

* 핸즈온 워크샵 #1: [깃헙 액션](https://youtu.be/e_elLW6uNSc)
* 핸즈온 워크샵 #2: [애저 정적 웹 앱](https://youtu.be/Hxkv6AjAisY)
* 핸즈온 워크샵 #3: [헤드리스 CMS로 정적 웹사이트 만들기](https://youtu.be/x3j3mDblqMY)


## 사전 준비 사항 ##

핸즈온 워크샵을 진행하면서 필요한 도구들에 대한 목록입니다.


### 개발 도구 ###

* 애저 계정: [무료 계정 생성하기](https://aka.ms/hackalearn/azure-free)
* Visual Studio Code: [다운로드](https://aka.ms/hackalearn/vscode)


### Gatsby 설치 ###

* nvm:
  * 윈도우: [다운로드](https://github.com/coreybutler/nvm-windows)
  * 리눅스/맥: [다운로드](https://github.com/nvm-sh/nvm)
* node.js: 14.x LTS
  * 윈도우 명령어: `nvm install 14.x.y` &ndash; `x`, `y`는 14 LTS 버전 넘버
  * 리눅스/맥 명령어: `nvm install --lts`
* yarn: `npm install -g yarn`
* gatsby CLI: `npm install -g gatsby-cli`


### 애저 펑션 설치 ###

* .NET Core SDK:
  * 3.1 LTS: [다운로드](https://aka.ms/hackalearn/dotnet/3.1)
  * 5.0: [다운로드](https://aka.ms/hackalearn/dotnet/5.0)
* Azure Functions Core Tools: `npm i -g azure-functions-core-tools@3 --unsafe-perm true`


### 애저 정적 웹 CLI 설치 ###

* ASWA CLI: `npm install -g @azure/static-web-apps-cli`


### Wordpress.com 블로그 생성 ###

* https://wordpress.com 계정 생성
* 블로그 사이트 생성


## 로컬 개발 환경에서 애플리케이션 실행 ##

위의 개발 도구들을 다 설치하셨다면 아래 순서를 통해 애플리케이션을 로컬 개발 환경에서 실행시킬 수 있습니다.


### 애저 펑션 실행 ###

1. 윈도우의 경우 파워셸 콘솔, 맥/리눅스의 경우 터미널을 열고 클론 받은 프로젝트의 루트 디렉토리로 이동합니다.
2. 아래 명령어를 통해 API 디렉토리로 이동헙니다.

    ```bash
    `cd api`
    ```

3. `local.settings.sample.json` 파일 이름을 `local.settings.json` 으로 바꿉니다.
4. `local.settings.json` 파일을 열어 `BLOG_URI` 값을 자신의 워드프레스닷컴 블로그 주소로 설정하고 저장합니다.
5. 아래 명령어를 차례로 실행시켜 애플리케이션을 빌드합니다.

    ```bash
    dotnet restore .
    dotnet build .
    ```

6. 아래 명령어를 실행시켜 애저 펑션 앱을 실행시킵니다.

    ```bash
    func start
    ```

7. 웹 브라우저를 열고 주소창에 아래 주소를 입력해서 블로그 포스트 리스트가 제대로 출력되는지 확인합니다.

    ```text
    http://localhost:7071/api/posts
    ```


### 갯츠비 앱 실행 ###

1. 새 파워셸 콘솔(윈도우), 새 터미널(맥/리눅스)을 열고 클론 받은 프로젝트의 루트 디렉토리로 이동합니다.
2. 아래 명령어를 통해 갯츠비 앱 디렉토리로 이동합니다.

    ```bash
    cd gatsby-app
    ```

3. 아래 명령어를 통해 현재 사용중인 node.js 버전을 14 LTS 버전으로 맞춥니다.

    ```bash
    # 윈도우 사용자 (14.17.4 버전으로 가정)
    nvm use 14.17.4

    # 맥/리눅스 사용자
    nvm use --lts=fermium
    ```

4. 갯츠비 앱을 실행시킵니다.

    ```bash
    gatsby develop
    ```

5. 웹 브라우저를 열고 주소창에 아래 주소를 입력해서 애플리케이션이 잘 실행되는지 확인합니다. 이 시점에서 워드프레스 블로그 포스트의 리스트는 보이지 않습니다. 웹브라우저의 개발자 도구 창을 열어 에러가 발생하는 것을 확인합니다.

    ```text
    http://localhost:8000
    ```


### SWA CLI 실행 ###

1. 새 파워셸 콘솔(윈도우), 새 터미널(맥/리눅스)을 열고 클론 받은 프로젝트의 루트 디렉토리로 이동합니다.
2. 아래 명령어를 통해 현재 사용중인 node.js 버전을 14 LTS 버전으로 맞춥니다.

    ```bash
    # 윈도우 사용자 (14.17.4 버전으로 가정)
    nvm use 14.17.4

    # 맥/리눅스 사용자
    nvm use --lts=fermium
    ```

3. 아래 명령어를 실행시켜 앞서 실행시켰던 두 애플리케이션을 통합합니다.

    ```bash
    swa start http://localhost:8000 --api ./api
    ```

4. 웹 브라우저를 열고 주소창에 아래 주소를 입력해서 애플리케이션이 잘 실행되는지 확인합니다. 이 시점에서 워드프레스 블로그 포스트의 리스트 역시 잘 보입니다.

    ```text
    http://localhost:4280
    ```
