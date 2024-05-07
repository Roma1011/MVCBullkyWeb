document.addEventListener('DOMContentLoaded', function() 
{
    function toggleFormVisibility(buttonId, formId) 
    {
        var button = document.getElementById(buttonId);
        var form = document.getElementById(formId);

        button.addEventListener('click', function(event) {
            event.preventDefault();
            form.style.display = (form.style.display === 'none' || form.style.display === '') ? 'block' : 'none';
        });
    }

    toggleFormVisibility('newCategory', 'new-category-form');
    toggleFormVisibility('edit', 'edit-category-form');

    document.addEventListener('click', function(event) 
    {
        var newCategoryForm = document.getElementById('new-category-form');
        var editCategoryForm = document.getElementById('edit-category-form');
        var newCategoryButton = document.getElementById('newCategory');
        var editButton = document.getElementById('edit');

        if (event.target === newCategoryButton || event.target === editButton) 
        {
            return;
        }
    
        if (newCategoryForm.style.display === 'block' && !newCategoryForm.contains(event.target)) 
        {
            newCategoryForm.style.display = 'none';
        }
    
        if (editCategoryForm.style.display === 'block' && !editCategoryForm.contains(event.target)) 
        {
            editCategoryForm.style.display = 'none';
        }
    });
});

function DeleteCategory(CategoryId)
{
    console.log(CategoryId)
    fetch("/Category/DeleteCategory?id=" + CategoryId, 
        {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
    })
        .then(response => 
        {
            if (response.ok) 
            {
                console.log("Category deleted successfully");
            } 
            else 
            {
                console.error("Failed to delete category");
            }
        })
        .catch(error => {
            console.error("Error:", error);
        });
}
