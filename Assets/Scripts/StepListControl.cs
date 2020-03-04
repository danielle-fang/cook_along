﻿using System.Collections;
using System.Collections.Generic;
using MagicLeapTools;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class StepListControl : MonoBehaviour
{
    private Color _highlightedColor;
    private Color _selectingColor;
    private Color _baseColor;
    private Color _viewportActiveColor;
    private List<GameObject> _buttons;
    public ControlInput controlInput;
    public static bool Selecting;
    private int _selectingRecipeIndex;
    public static float PrevNormPosition;
    public static ScrollRect ScrollRect;
    [SerializeField] private GameObject buttonTemplate;
    
    private void Awake()
    {
        controlInput.OnSwipe.AddListener(HandleSwipe);
        controlInput.OnTriggerPressEnded.AddListener(HandleTrigger);
        Selecting = false;
        ScrollRect = GetComponent<ScrollRect>();
    }

    void HandleTrigger()
    {
        if (Selecting)
        {
            StepCanvas.step_number = _selectingRecipeIndex;
            Image viewportImage = GameObject.Find("Viewport").GetComponent<Image>();
            viewportImage.color = Color.white;
            Selecting = false;
        }
    }
    
    void HandleSwipe(MLInputControllerTouchpadGestureDirection direction)
    {
        Image viewportImage = GameObject.Find("Viewport").GetComponent<Image>();
        
        if (!Selecting && direction == MLInputControllerTouchpadGestureDirection.Left)
        {
            viewportImage.color = _viewportActiveColor;
            Selecting = true;
            _selectingRecipeIndex = StepCanvas.step_number;
            PrevNormPosition = ScrollRect.verticalNormalizedPosition;
        }

        if (Selecting && direction == MLInputControllerTouchpadGestureDirection.Right)
        { 
            viewportImage.color = Color.white;
            Selecting = false;
            if (_selectingRecipeIndex != StepCanvas.step_number)
            {
                ScrollRect.verticalNormalizedPosition = PrevNormPosition;
            }
        }

        if (Selecting && direction == MLInputControllerTouchpadGestureDirection.Up && _selectingRecipeIndex	> 0)
        {
            ScrollRect.verticalNormalizedPosition += 0.2f;
            UpdateListRecipe(direction);

        }

        if (Selecting && direction == MLInputControllerTouchpadGestureDirection.Down && _selectingRecipeIndex < _buttons.Count - 1)
        {
            ScrollRect.verticalNormalizedPosition -= 0.2f;
            UpdateListRecipe(direction);
        }
    }

    void UpdateListRecipe(MLInputControllerTouchpadGestureDirection direction)
    {
        GameObject previousStep = _buttons[_selectingRecipeIndex];
        if (Selecting && direction == MLInputControllerTouchpadGestureDirection.Up)
        {
            _selectingRecipeIndex -= 1;
        }

        if (Selecting && direction == MLInputControllerTouchpadGestureDirection.Down)
        {
            _selectingRecipeIndex += 1;
        }

        GameObject nextStep = _buttons[_selectingRecipeIndex];
        previousStep.GetComponent<Image>().color = _baseColor;
        nextStep.GetComponent<Image>().color = _selectingColor;
    }
    
    
    
    void UpdateActiveRecipe()
    {
        if (!Selecting)
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                Image buttonImage = _buttons[i].GetComponent<Image>();
                buttonImage.color = i == StepCanvas.step_number ? _highlightedColor : _baseColor;
            }  
        }
        
    }
    
    
    void Start()
    {
        _highlightedColor = new Color(0.937f, 0.741f, 0.42f);
        _viewportActiveColor = new Color(0f, 0.9f, 0.9f);
        _selectingColor = new Color	(0f, 0.7f, 0.9f);
        _baseColor = new Color(1f, 1f, 1f);
        _buttons = new List<GameObject>();
        
        List<RecipeStep> steps = RecipeMenuList.SelectedRecipe.steps;
        for (int i = 0; i < steps.Count; i++)
        {
            GameObject button = Instantiate(buttonTemplate);
            button.SetActive(true);
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = i == 0 ? _highlightedColor : _baseColor;
            int stepNumber = i + 1;
            RecipeStep step = steps[i];
            button.GetComponent	<StepListButton>().SetText	("  " + stepNumber + ". " + step.instruction);
            button.transform.SetParent	(buttonTemplate.transform.parent, false);
            _buttons.Add(button);
        }
    }

    void Update()
    {
        UpdateActiveRecipe();
    }
}