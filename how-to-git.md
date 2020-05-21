### Step 0
Fork this repo.

### Step1
Set up your fork to track changes on the main repo:

`git remote add upstream git@github.com:042020-dotnet-uta/jaysonlennon-repo2.git`

### Step 2
Get the latest information from the main repo:

`git fetch upstream`

### Step 3
Checkout the develop branch so you have the correct code before you create your feature branch:

`git checkout --track upstream/develop`

### Step 4
Checkout your feature branch:

`git checkout -b my-feature-branch`

### Step 5
Work on your feature

### Step 6
Add the changes (this can be done as many times as you need):

`git add .`

### Step 7
Commit changes (this can be done as many times as you need):

`git commit -m "commit message"`

### Step 8
Retrieve the latest code from the main repo:

`git pull upstream develop`


### Step 9
#### A
If everything is fine, then you will not get any errors and can proceed to __Step 10__.

#### B
If you get a merge conflict, they must be fixed first.
Use `git status` to view which files have conflicts (they will be under *unmerged paths*).
An example of how a merge conflict will appear in the file:

```
unaffected code
<<<<<<< HEAD
this is the code in your branch
=======
this is the code in the main repo
>>>>>>> upstream/develop
unaffected code
```

To fix this, code must be moved or corrected so the lines do not conflict (there may be more than 1).
The `=======` acts as a separator between the offending lines, with your code above, and the main repo's code below.
Make sure to remove `<<<<<<< HEAD`, `=======` and `>>>>>>> upstream/develop` when making your corrections.
Also note that many IDEs will just let you click on which change you want to keep, so you may not have to manually fix conflicts.

If the conflict is a file that was deleted and it is no longer needed, you can use `git rm filename` to remove it, followed by a `git commit -m "message"`.

After any conflicts are resolved, run `git add .` followed by `git commit -m "commit message after fixing conflicts"`

### Step 10
Push your feature branch into your fork of the repo:

`git push --set-upstream origin my-feature-branch`

### Step 11
Once your branch is pushed to your fork:
  * Go to Github on your fork of the repo
  * Click "Create pull request"
  * On the "base" dropdown, select "develop"
  * On the "compare" dropdown, select `my-feature-branch`
  * If you get a _green checkmark_, click on "Create pull request"
    * If you get a _red X_, then go back to __Step 9__ and repeat the process.
