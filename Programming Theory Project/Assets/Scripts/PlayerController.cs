using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Camera GameCamera;
    public Camera StickCamera;
    private Player m_Selected = null;
    public GameObject Marker;
    public GameObject TeamPanel;
    private bool m_SwitchCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_Selected != null)
            {
                m_Selected.isTarget = false;
            }
            HandleSelection();
            MarkerAction();
            StickCameraAction();
            GreetingPanelAction();
        }
        if (Input.GetKeyDown(KeyCode.T) && m_Selected != null)
        {    
            if (!m_SwitchCamera)
            {
                GameCamera.enabled = false;
                StickCamera.enabled = true;
                m_SwitchCamera = !m_SwitchCamera;
            }
            else
            {
                StickCamera.enabled = false;
                GameCamera.enabled = true;
                m_SwitchCamera = !m_SwitchCamera;
            }
        }
       
    }

    void MarkerAction()
    {
        if (m_Selected != null && Marker.transform.parent != m_Selected.transform)
        {
            Marker.transform.SetParent(m_Selected.transform, false);
            Marker.transform.localPosition = Vector3.zero;
            Marker.transform.localScale = Vector3.one / Mathf.Sqrt(m_Selected.transform.localScale.sqrMagnitude / 3);
            Marker.SetActive(true);
            m_Selected.isTarget = true;
        }
        else if (m_Selected == null && Marker.activeInHierarchy)
        {
            Marker.SetActive(false);
            Marker.transform.SetParent(null);
            
        }
    }
    
    // move a camera to follow the selected player
    void StickCameraAction()
    {
        // offset the camera to the player's eye level
        
        if (m_Selected != null && StickCamera.transform.parent != m_Selected.transform)
        {
            Vector3 m_offset = new Vector3 (0, m_Selected.GetComponent<BoxCollider>().center.y * 2, 0);
            StickCamera.transform.SetParent(m_Selected.transform, false);
            StickCamera.transform.localPosition = Vector3.zero + m_offset;
            // StickCamera.transform.LookAt(m_Selected.transform);
        }
        else if (m_Selected == null)
        {
            StickCamera.enabled = false;
            StickCamera.transform.SetParent(null);
            
        }
    }

    void HandleSelection()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var player = hit.collider.GetComponent<Player>();
            Debug.Log(player);
            m_Selected = player;
            
        }
    }

    void GreetingPanelAction()
    {
        if (m_Selected != null)
        {
            TeamPanel.GetComponentInChildren<TextMeshProUGUI>().text = m_Selected.GetName();
            TeamPanel.GetComponent<Image>().color = m_Selected.GetColor();
            TeamPanel.SetActive(true);
        }
        else 
        {
            TeamPanel.SetActive(false);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }



}
