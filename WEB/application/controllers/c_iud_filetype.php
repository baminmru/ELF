﻿<?php
	 class C_iud_filetype extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'iud_filetype.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'iud_filetype.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'iud_filetypeid' =>  $this->input->get_post('iud_filetypeid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'allowtiming' =>   $this->input->get_post('allowtiming', TRUE)
            );
            $iud_filetype = $this->m_iud_filetype->setRow($data);
            print json_encode($iud_filetype);
    }
    function newRow() {
            log_message('debug', 'iud_filetype.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'iud_filetypeid' =>  $this->input->get_post('iud_filetypeid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'allowtiming' =>   $this->input->get_post('allowtiming', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $iud_filetype= $this->m_iud_filetype->newRow($instanceid,$data);
            $return = $iud_filetype;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'iud_filetype.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $iud_filetype = $this->m_iud_filetype->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $iud_filetype
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $iud_filetype= $this->m_iud_filetype->getRowsByInstance($instanceid,$sort);
                }else{
                    $iud_filetype= $this->m_iud_filetype->getRows($sort);
                }
            }else{
              $iud_filetype= $this->m_iud_filetype->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $iud_filetype
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'iud_filetype.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $iud_filetype= $this->m_iud_filetype->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $iud_filetype
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'iud_filetype.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $iud_filetype= $this->m_iud_filetype->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $iud_filetype
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'iud_filetype.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('iud_filetypeid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_iud_filetype->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_iud_filetype', 'm_iud_filetype');
    }
}
?>