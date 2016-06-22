## Configure git to store big analytics database
1. Install “Git Large File Storage” from the site https://git-lfs.github.com/
1. Open Git CMD and go to the folder where the repository is located
1. Enter command *git lfs install*
1. Enter command *git lfs track* and ensure you have \*.mdf in a tracking list. If you don’t have \*.mdf, enter command *git lfs track “*.mdf”*

When you finish, you can continue work with repository as before and push big files to the repository.
