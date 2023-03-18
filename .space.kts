job("Hello world")  {
    startOn {
        gitPush {
            branchFilter {
                +"refs/heads/master"
            }
        }
    }

    container(displayName = "Say hello", image = "hello-world")
}
